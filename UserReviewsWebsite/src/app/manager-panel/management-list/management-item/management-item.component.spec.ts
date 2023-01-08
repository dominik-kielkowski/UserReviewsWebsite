import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagementItemComponent } from './management-item.component';

describe('ManagementItemComponent', () => {
  let component: ManagementItemComponent;
  let fixture: ComponentFixture<ManagementItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagementItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManagementItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
