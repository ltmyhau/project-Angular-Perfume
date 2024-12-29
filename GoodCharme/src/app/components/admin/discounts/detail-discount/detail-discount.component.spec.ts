import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailDiscountComponent } from './detail-discount.component';

describe('DetailDiscountComponent', () => {
  let component: DetailDiscountComponent;
  let fixture: ComponentFixture<DetailDiscountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetailDiscountComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DetailDiscountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
