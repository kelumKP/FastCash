import { TestBed } from '@angular/core/testing';
import { LoanApplicationComponent } from './loan-application.component';
describe('LoanApplicationComponent', () => {
    let component;
    let fixture;
    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [LoanApplicationComponent]
        })
            .compileComponents();
        fixture = TestBed.createComponent(LoanApplicationComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=loan-application.component.spec.js.map