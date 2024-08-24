import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core'; // Import this for module-based providers
import { FormsModule } from '@angular/forms'; // Import FormsModule
export const appConfig = {
    providers: [
        provideRouter(routes),
        provideHttpClient(withFetch()),
        importProvidersFrom(FormsModule), // Use importProvidersFrom to provide FormsModule
    ],
};
//# sourceMappingURL=app.config.js.map