import { TestBed } from '@angular/core/testing';

import { MomoPaymentService } from './momo-payment.service';

describe('MomoPaymentService', () => {
  let service: MomoPaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MomoPaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
