import { Article } from "./article";

export interface Comment {
  commentId :number;
  text :string;
  name :string;
  LastName? :string;
  Email? :string;
  commentDate :string;
  commentLike? :number;
  commentDislike? :number;
  articleId:number;
}
