import { TestBed } from '@angular/core/testing';

import { TransizioneService } from './transizione.service';

describe('TransizioneService', () => {
  let service: TransizioneService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransizioneService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
