export interface ArticleCreateDTO {
  title: string;
  content: string;
  categoryIds: number[];
  imageUrl: string | null;
}
