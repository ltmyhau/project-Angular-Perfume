import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailProductTypeComponent } from './detail-product-type.component';

describe('DetailProductTypeComponent', () => {
  let component: DetailProductTypeComponent;
  let fixture: ComponentFixture<DetailProductTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetailProductTypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DetailProductTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
