import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CommentService } from 'src/app/services/comment.service';

@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.css']
})
export class AddCommentComponent implements OnInit {

  commentForm: FormGroup | any;
  success: boolean | undefined;
  info: string | undefined;

  constructor(private fb: FormBuilder, private commentService: CommentService, private route:ActivatedRoute){

  }

  ngOnInit(): void {
    this.commentForm = new FormGroup({
      name: new FormControl("", Validators.required),
      text: new FormControl("", Validators.required),
      articleId:new FormControl("")
    })
  }

  onSubmit(){
    if (this.commentForm.valid) {
      let id = Number(this.route.snapshot.paramMap.get("id"));
      this.commentForm.controls['articleId'].setValue(id);
      this.commentService.addComment(this.commentForm.value).subscribe(data=>{
        this.success=true;
        this.info="Yorumunuz eklendi."
        setTimeout(() => {
          this.success = false;
        }, 4000);
        this.commentForm.reset();
        this.commentService.commentList(id).subscribe(data=>{
          
        });
      },error=>{
        this.success=false;
      })
    }
  }
}
