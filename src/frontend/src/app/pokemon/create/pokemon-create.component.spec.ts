import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PokemonCreateComponent } from './pokemon-create.component';

describe('PokemonCreateComponent', () => {
  let component: PokemonCreateComponent;
  let fixture: ComponentFixture<PokemonCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PokemonCreateComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PokemonCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
