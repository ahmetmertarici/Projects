import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Article } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent{
  @Input() currentRating: number | null = null;
  @Output() rate: EventEmitter<number> = new EventEmitter<number>();
  hoveredStar: number | null = null;
  isRated: boolean = false;
  ratedStar: number | null = null;

  onClick(star: number): void {
    if (!this.isRated) {
      this.isRated = true;
      this.ratedStar = star;
      this.rate.emit(star);
    }
  }

  onMouseEnter(star: number): void {
    this.hoveredStar = star;
  }

  onMouseLeave(): void {
    this.hoveredStar = null;
  }
}
