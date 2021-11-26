export interface RecipeCard {
  id: number;
  imageUrl: string;

  authorUsername: string

  title: string;
  description: string;

  tags: string[];

  isFavourite: boolean;
  isLiked: boolean;

  favouritesCount: number;
  likesCount: number;
  cookingTime: number;
  personsCount: number;
}
