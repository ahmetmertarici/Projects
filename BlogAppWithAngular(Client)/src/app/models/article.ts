import { Category } from "./category";

export interface Article {
  articleId:number;
  title:string;
  content:string;
  createDate:string;
  viewsCount:number;
  score:number;
  scoreCount:number;
  imageUrl:string;
  commentCount:number;
  categories: Category[];
  categoryIds: number[]; 
}
