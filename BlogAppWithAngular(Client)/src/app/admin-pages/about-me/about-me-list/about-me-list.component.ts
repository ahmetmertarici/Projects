import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Aboutme } from 'src/app/models/aboutme';
import { AboutmeService } from 'src/app/services/aboutme.service';

@Component({
  selector: 'app-about-me-list',
  templateUrl: './about-me-list.component.html',
  styleUrls: ['./about-me-list.component.css']
})
export class AboutMeListComponent {
  aboutMe:Aboutme[]=[];
  displayedColumns = ['id', 'title', 'isApproved', 'actions'];

  deleteDialogTemplate: TemplateRef<any> | null = null;
  @ViewChild('deleteDialogTemplate') set deleteDialog(content: TemplateRef<any> | null) {
    this.deleteDialogTemplate = content;
  }

  constructor(private aboutmeService:AboutmeService, private dialog: MatDialog){}
  ngOnInit(): void {
    this.getAllAboutMe();
  }


  getAllAboutMe(){
    this.aboutmeService.getAllAboutMe().subscribe(data=>{
      this.aboutMe=data;
    })
  }

  onIsApprovedChange(articleId: number): void {
    this.aboutmeService.updateAboutMeIsApproved(articleId).subscribe(() => {
      this.getAllAboutMe();
    });
  }

  openDeleteConfirmation(aboutMeId: number, categoryName: string): void {
    const dialogRef = this.dialog.open(this.deleteDialogTemplate as TemplateRef<any>, {
      data: { message: `Kategoriyi silmek istediğinize emin misiniz: ${categoryName}?` }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'yes') {
        this.aboutmeService.deleteAboutMe(aboutMeId).subscribe(() => {
          this.getAllAboutMe();
        });
      }
    });
  }

}
