const express = require('express');
const cors = require('cors');
const axios = require('axios');
const crypto = require('crypto');

const app = express();

app.use(express.json());
// app.use(express.urlencoded({ extended: true }));

const corsOptions = {
    origin: 'http://localhost:4200',
    methods: ['GET', 'POST', 'OPTIONS'],
    allowedHeaders: ['Content-Type', 'Authorization'],
};
  
app.use(cors(corsOptions));
app.options('*', cors(corsOptions));


var accessKey = 'F8BBA842ECF85';
var secretKey = 'K951B6PE1waDMi640xX08PD3vg6EkVlz';

app.post("/payment", async(req, res) => {
    //https://developers.momo.vn/#/docs/en/aiov2/?id=payment-method
    //parameters
    // var accessKey = 'F8BBA842ECF85';
    // var secretKey = 'K951B6PE1waDMi640xX08PD3vg6EkVlz';
    // var orderInfo = 'pay with MoMo';
    console.log("Request từ frontend:", req.body);
    const { orderId, amount, orderInfo } = req.body;
    if (!orderId || !amount || !orderInfo) {
        return res.status(400).json({ message: 'Thiếu thông tin yêu cầu' });
    }

    var partnerCode = 'MOMO';
    var redirectUrl = 'http://localhost:4200/payment-complete';
    var ipnUrl = 'https://b135-123-21-172-237.ngrok-free.app/callback';
    var requestType = "payWithMethod";
    // var amount = '50000';
    // var orderId = partnerCode + new Date().getTime();
    var requestId = orderId;
    var extraData ='';
    var orderGroupId ='';
    var autoCapture =true;
    var lang = 'vi';

    //before sign HMAC SHA256 with format
    //accessKey=$accessKey&amount=$amount&extraData=$extraData&ipnUrl=$ipnUrl&orderId=$orderId&orderInfo=$orderInfo&partnerCode=$partnerCode&redirectUrl=$redirectUrl&requestId=$requestId&requestType=$requestType
    var rawSignature = "accessKey=" + accessKey + "&amount=" + amount + "&extraData=" + extraData + "&ipnUrl=" + ipnUrl + "&orderId=" + orderId + "&orderInfo=" + orderInfo + "&partnerCode=" + partnerCode + "&redirectUrl=" + redirectUrl + "&requestId=" + requestId + "&requestType=" + requestType;
    //puts raw signature
    console.log("--------------------RAW SIGNATURE----------------")
    console.log(rawSignature)
    //signature
    const crypto = require('crypto');
    var signature = crypto.createHmac('sha256', secretKey)
        .update(rawSignature)
        .digest('hex');
    console.log("--------------------SIGNATURE----------------")
    console.log(signature)

    //json object send to MoMo endpoint
    const requestBody = JSON.stringify({
        partnerCode : partnerCode,
        partnerName : "Test",
        storeId : "MomoTestStore",
        requestId : requestId,
        amount : amount,
        orderId : orderId,
        orderInfo : orderInfo,
        redirectUrl : redirectUrl,
        ipnUrl : ipnUrl,
        lang : lang,
        requestType: requestType,
        autoCapture: autoCapture,
        extraData : extraData,
        orderGroupId: orderGroupId,
        signature : signature
    });
    
    //option for axios
    const options = {
        method: 'POST',
        url: 'https://test-payment.momo.vn/v2/gateway/api/create',
        headers: {
          'Content-Type': 'application/json',
          'Content-Length': Buffer.byteLength(requestBody),
        },
        data: requestBody,
    };

    try {
        const response = await axios(options);
        console.log("Phản hồi từ MoMo:", response.data); 

        if (response.data.payUrl) {
            return res.status(200).json({ payUrl: response.data.payUrl });
        } else {
            return res.status(500).json({ message: 'Phản hồi từ MoMo không chứa URL thanh toán.' });
        }
    } catch (error) {
        console.error('Lỗi gọi API MoMo:', error.response?.data || error.message);
        return res.status(500).json({ message: 'Lỗi khi kết nối API MoMo', error: error.response?.data });
    }
})

app.post('/callback', async (req, res) => {
    console.log('callback: ', req.body);
    return res.status(204).json(req.body);
});

app.post('/check-status-transaction', async (req, res) => {
    const { orderId } = req.body;

    const rawSignature = `accessKey=${accessKey}&orderId=${orderId}&partnerCode=MOMO&requestId=${orderId}`;
  
    const signature = crypto
      .createHmac('sha256', secretKey)
      .update(rawSignature)
      .digest('hex');
  
    const requestBody = JSON.stringify({
      partnerCode: 'MOMO',
      requestId: orderId,
      orderId: orderId,
      signature: signature,
      lang: 'vi',
    });
  
    // options for axios
    const options = {
      method: 'POST',
      url: 'https://test-payment.momo.vn/v2/gateway/api/query',
      headers: {
        'Content-Type': 'application/json',
      },
      data: requestBody,
    };
  
    const result = await axios(options);
  
    return res.status(200).json(result.data);
});

app.listen(5000, () => {
    console.log("server run at port 5000");
})