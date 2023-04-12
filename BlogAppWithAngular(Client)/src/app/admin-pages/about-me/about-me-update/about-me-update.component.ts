import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import DecoupledEditor from '@ckeditor/ckeditor5-build-decoupled-document';
import { AboutmeService } from 'src/app/services/aboutme.service';

@Component({
  selector: 'app-about-me-update',
  templateUrl: './about-me-update.component.html',
  styleUrls: ['./about-me-update.component.css']
})
export class AboutMeUpdateComponent implements OnInit {

 updateAboutMeForm: FormGroup;
 aboutMeId:number;

 public Editor = DecoupledEditor;
 onEditorReady(editor: any) {
   editor.ui.getEditableElement().parentElement.insertBefore(
     editor.ui.view.toolbar.element,
     editor.ui.getEditableElement()
   );
 }

  constructor(private fb: FormBuilder, private aboutmeService: AboutmeService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.updateAboutMeForm = this.fb.group({
      content: ['', Validators.required],
      title: ['', Validators.required]
    });
    this.aboutMeId = parseInt(this.activatedRoute.snapshot.paramMap.get('id') || '0', 10);
  }



  async ngOnInit() {
    const aboutMe =await this.aboutmeService.getAboutMe(this.aboutMeId).toPromise();
    if (aboutMe) {
      this.updateAboutMeForm.patchValue({
        content: aboutMe.content,
        title:aboutMe.title
      });
    }
  }


  onSubmit(){
    if (this.updateAboutMeForm.valid) {

      const formData = new FormData();
      formData.append('content', this.updateAboutMeForm.get('content')?.value);
      formData.append('title', this.updateAboutMeForm.get('title')?.value);

      this.aboutmeService.updateAboutMe(this.aboutMeId, formData).subscribe(
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
