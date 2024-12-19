import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
const api = 'http://localhost:5094/api';

@Injectable({
  providedIn: 'root'
})

export class AppService {

  constructor( private http:HttpClient ) { }

  productsNew(limit: number = 10): any {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamMoi?limit=`+limit);
  }

  productsBestSeller(limit: number = 10): any {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamBanChay?limit=`+limit);
  }

  productsList():Observable<any[]> {
    return this.http.get<any>(`${api}/SanPham`);
  }

  productDetail(id: string = 'SP000001'): any {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamTheoMaSP?id=`+id);
  }

  productsByMaLoaiSP(id: string = 'LSP000001'): any {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamTheoMaLoaiSP?id=`+id);
  }

  productsByMaSP(idSP: any = 'SP000001'): any {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamTheoMaSP?id=`+idSP);
  }

  relatedProducts(limit: number = 5): any {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamNgauNhien?limit=`+limit);
  }

  NuocHoaList():Observable<any[]> {
    return this.http.get<any>(`${api}/SanPham/GetNuocHoa`);
  }

  SanPhamKhacList():Observable<any[]> {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamKhac`);
  }

  productsByPrice(tuGia: number = 0, denGia: number = 9999999999): any {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamTheoGia?tuGia=`+tuGia+`&denGia=`+denGia);
  }

  productsTypeList():Observable<any[]> {
    return this.http.get<any>(`${api}/LoaiSP`);
  }

  addProduct(data: any):Observable<any> {
    return this.http.post<any>(`${api}/SanPham`, data);
  }

  editProduct(data: any):Observable<any> {
    return this.http.put<any>(`${api}/SanPham`, data);
  }

  deleteProduct(id: number):Observable<any> {
    return this.http.delete<any>(`${api}/SanPham/`+id);
  }

  orderList():Observable<any[]> {
    return this.http.get<any>(`${api}/DonHang`);
  }

  orderStatusList():Observable<any[]> {
    return this.http.get<any>(`${api}/TinhTrangDonHang`);
  }

  orderByID(idSP: any = 1):Observable<any[]> {
    return this.http.get<any>(`${api}/DonHang/GetDonHangTheoMaDH?id=`+idSP);
  }

  editOrder(data: any):Observable<any> {
    return this.http.put<any>(`${api}/DonHang`, data);
  }

  addOrder(data: any):Observable<any> {
    return this.http.post<any>(`${api}/DonHang`, data);
  }

  addOrderDetails(orderDetails: any[]): Observable<any> {
    return this.http.post<any>(`${api}/ChiTietDonHang/`, orderDetails);
  }

  getOrderDetailsByOrderId(orderId: string): Observable<any[]> {
    return this.http.get<any[]>(`${api}/ChiTietDonHang/${orderId}`);
  }  

  customerByID(idSP: any = 1): any {
    return this.http.get<any>(`${api}/KhachHang/GetKhachHangTheoMaKH?id=`+idSP);
  }

  searchProduct(searchTerm: string) {
    return this.http.get<any>(`${api}/SanPham/SearchSanPham?search=`+searchTerm);
  }

  editCustomerInfo(maKH: string, data: any):Observable<any> {
    return this.http.put<any>(`${api}/KhachHang/update-info/${maKH}`, data);
  }

  editCustomerAddress(maKH: string, data: any):Observable<any> {
    return this.http.put<any>(`${api}/KhachHang/update-address/${maKH}`, data);
  }

  updatePassword(username: string, newPassword: string): Observable<any> {
    return this.http.put<any>(`${api}/TaiKhoan/update-password`, { username, password: newPassword });
  }

  // getPaymentStatus(orderId: string): Observable<any> {
  //   return this.http.get<any>(`https://b135-123-21-172-237.ngrok-free.app/check-status-transaction?orderId=${orderId}`);
  // }
  private apiUrl = 'http://localhost:5000'; 
  getPaymentStatus(orderId: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/check-status-transaction`, { orderId });
  }
}
