export interface Comment {
  CommentId :number;
  text :string;
  name :string;
  LastName? :string;
  Email? :string;
  commentDate :string;
  CommentLike? :number;
  CommentDislike? :number;
  ArticleId:number;
}
