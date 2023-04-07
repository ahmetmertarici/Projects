import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { HelperService } from 'src/app/services/helper.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  contactForm: FormGroup | any;
  loading: boolean | undefined;
  success: boolean | undefined;
  info: string | undefined;

  constructor(private helperService: HelperService) { }
  ngOnInit(): void {

    this.contactForm = new FormGroup({
      name: new FormControl("", Validators.required),
      email: new FormControl("", [Validators.required, Validators.email]),
      subject: new FormControl("", Validators.required),
      message: new FormControl("", [Validators.required, Validators.minLength(5)])
    })

  }

  GetValidationMessages(f: AbstractControl, name: string) {
    if (f.errors) {
      for (let errroName in f.errors) {
        if (errroName == "required") return `${name} alanı boş bırakılamaz`;
        else if (errroName == "email") return `email formatı yanlış`;
        else if (errroName == "minlength")
          return `${name} alanız en az 5 karakter olmalıdır.`;
      }
    }
    return null;
  }

  get getControls() {
    return this.contactForm.controls;
  }

  onsubmit() {
    if (this.contactForm?.valid) {
      this.helperService.sendContactEmail(this.contactForm.value).subscribe(
        data => {
          this.loading = false;
          this.success = true;
          this.contactForm?.reset();
          this.info = "Mesajınız alınmıştır.";
        },
        error => {
          this.loading = false;
          this.success = false;
          this.info = "Lütfen tekrar deneyiniz.";
        }
      );
    }
  }


}


