export interface RecipeCard {
  id: number;
  imageUrl: string;

  authorUsername: string

  title: string;
  description: string;

  tags: string[];

  isFavourite: boolean;
  isLiked: boolean;

  favourite: number;
  likes: number;
  time: number;
  personsCount: number;
}
