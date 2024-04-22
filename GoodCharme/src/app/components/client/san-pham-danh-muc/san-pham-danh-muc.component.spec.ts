import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SanPhamDanhMucComponent } from './san-pham-danh-muc.component';

describe('SanPhamDanhMucComponent', () => {
  let component: SanPhamDanhMucComponent;
  let fixture: ComponentFixture<SanPhamDanhMucComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SanPhamDanhMucComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SanPhamDanhMucComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
