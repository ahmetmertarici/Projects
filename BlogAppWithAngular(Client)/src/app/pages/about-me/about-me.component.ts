import { Component, OnInit } from '@angular/core';
import { Aboutme } from 'src/app/models/aboutme';
import { AboutmeService } from 'src/app/services/aboutme.service';

@Component({
  selector: 'app-about-me',
  templateUrl: './about-me.component.html',
  styleUrls: ['./about-me.component.css']
})
export class AboutMeComponent implements OnInit {

  aboutMe:Aboutme[]=[];

  constructor(private aboutmeService:AboutmeService){}

  ngOnInit() {
    this.aboutmeService.getAboutMeContent().subscribe(data=>{
      this.aboutMe=data;
      console.log(data);

    })
  }

}
