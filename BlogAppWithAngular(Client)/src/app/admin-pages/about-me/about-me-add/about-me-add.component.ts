import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import DecoupledEditor from '@ckeditor/ckeditor5-build-decoupled-document';
import { AboutmeService } from 'src/app/services/aboutme.service';

@Component({
  selector: 'app-about-me-add',
  templateUrl: './about-me-add.component.html',
  styleUrls: ['./about-me-add.component.css']
})
export class AboutMeAddComponent {
  fileData: File | null = null;
  createAboutMeForm: FormGroup;

  public Editor = DecoupledEditor;
  onEditorReady(editor: any) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }


  constructor(private fb: FormBuilder, private aboutmeService: AboutmeService, private router: Router) {
    this.createAboutMeForm = this.fb.group({
      content: ['', Validators.required],
      title: ['', Validators.required]

    });
  }


  onSubmit(){
    if (this.createAboutMeForm.valid) {

      const formData = new FormData();
      formData.append('content', this.createAboutMeForm.get('content')?.value);
      formData.append('title', this.createAboutMeForm.get('title')?.value);

      this.aboutmeService.createAboutMe(formData).subscribe(
        (result) => {
          console.log("eklendi");
          this.router.navigate(['/admin/hakkimda-düzenle/liste']);
        },
        (error) => {
          console.error("Hata nesnesi:", error);
        }
      );
    }
  }


}
