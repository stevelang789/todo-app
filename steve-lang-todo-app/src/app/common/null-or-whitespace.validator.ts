import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const nullOrWhiteSpaceValidator: ValidatorFn = (
  control: AbstractControl,
): ValidationErrors | null => {
  const value = control.value as string;
  return (!value || value.trim().length === 0)
    ? { isNullOrWhiteSpace: true }
    : null;
};
