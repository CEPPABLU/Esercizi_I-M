import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OggettoComponent } from './oggetto.component';

describe('OggettoComponent', () => {
  let component: OggettoComponent;
  let fixture: ComponentFixture<OggettoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OggettoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OggettoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
