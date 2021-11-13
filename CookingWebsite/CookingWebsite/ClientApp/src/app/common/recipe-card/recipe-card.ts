export class RecipeCard {
  imageUrl: string;

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
