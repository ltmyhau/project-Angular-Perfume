import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SanPhamChiTietComponent } from './san-pham-chi-tiet.component';

describe('SanPhamChiTietComponent', () => {
  let component: SanPhamChiTietComponent;
  let fixture: ComponentFixture<SanPhamChiTietComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SanPhamChiTietComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SanPhamChiTietComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
