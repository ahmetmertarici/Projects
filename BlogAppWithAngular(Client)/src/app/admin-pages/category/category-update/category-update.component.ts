import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-category-update',
  templateUrl: './category-update.component.html',
  styleUrls: ['./category-update.component.css']
})
export class CategoryUpdateComponent implements OnInit{

  updateCategoryForm: FormGroup;
  categoryId:number;

  constructor(private fb: FormBuilder, private adminService: AdminService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.updateCategoryForm = this.fb.group({
      categoryName: ['', Validators.required],
    });
    this.categoryId = parseInt(this.activatedRoute.snapshot.paramMap.get('id') || '0', 10);
  }



  async ngOnInit() {
    const category =await this.adminService.getCategory(this.categoryId).toPromise();
    if (category) {
      this.updateCategoryForm.patchValue({
        categoryName: category.categoryName
      });
    }
  }


  onSubmit(){
    if (this.updateCategoryForm.valid) {

      const formData = new FormData();
      formData.append('categoryName', this.updateCategoryForm.get('categoryName')?.value);

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
