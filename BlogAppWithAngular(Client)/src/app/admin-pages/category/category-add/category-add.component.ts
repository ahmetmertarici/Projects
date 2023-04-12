import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.css']
})
export class CategoryAddComponent implements OnInit {
  fileData: File | null = null;
  createCategoryForm: FormGroup;
  constructor(private fb: FormBuilder, private adminService: AdminService, private router: Router) {
    this.createCategoryForm = this.fb.group({
      categoryName: ['', Validators.required]
    });
  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  onSubmit(){
    if (this.createCategoryForm.valid) {

      const formData = new FormData();
      formData.append('categoryName', this.createCategoryForm.get('categoryName')?.value);

      this.adminService.createCategory(formData).subscribe(
        (result) => {
          console.log("eklendi");
          this.router.navigate(['/admin/kategori/liste']);
        },
        (error) => {
          console.error("Hata nesnesi:", error);
        }
      );
    }
  }









}
