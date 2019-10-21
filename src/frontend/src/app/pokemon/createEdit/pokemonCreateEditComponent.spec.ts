import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PokemonCreateEditComponent } from './pokemonCreateEditComponent';

describe('PokemonCreateEditComponent', () => {
  let component: PokemonCreateEditComponent;
  let fixture: ComponentFixture<PokemonCreateEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PokemonCreateEditComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PokemonCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
