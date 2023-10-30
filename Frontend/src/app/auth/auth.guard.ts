//CanActivateFn is a type that represents a function used as a guard for route activation.
import { CanActivateFn } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  return true;
};
