// src/app/shared/validators/array-required.validator.ts
import { AbstractControl, ValidatorFn } from '@angular/forms';

export function arrayRequiredValidator(): ValidatorFn {
  return (control: AbstractControl): {[key: string]: any} | null => {
    const selectedValues = control.value;
    return selectedValues && selectedValues.length > 0 ? null : { arrayRequired: true };
  };
}
