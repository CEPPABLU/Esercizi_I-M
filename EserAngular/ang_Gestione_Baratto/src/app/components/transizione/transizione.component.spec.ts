import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransizioneComponent } from './transizione.component';

describe('TransizioneComponent', () => {
  let component: TransizioneComponent;
  let fixture: ComponentFixture<TransizioneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TransizioneComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TransizioneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
