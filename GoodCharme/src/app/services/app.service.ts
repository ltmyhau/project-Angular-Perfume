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

  productDetail(id: number = 1): any {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamTheoMaSP?id=`+id);
  }

  productsByMaLoaiSP(idSP: number = 1): any {
    return this.http.get<any>(`${api}/SanPham/GetSanPhamTheoMaLoaiSP?id=`+idSP);
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

  login(val: any):Observable<any[]> {
    return this.http.post<any>(`${api}/TaiKhoan/login`, val);
  }
}
