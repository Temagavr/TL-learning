import { RecipeIngredientDto } from './recipe-ingredient-dto';

export interface RecipeDetailsDto {
  imageUrl: string;

  authorUsername: string

  title: string;
  description: string;

  tags: string[];

  isFavourite: boolean;
  isLiked: boolean;

  favourite: number;
  likes: number;
  cookingTime: number;
  personsCount: number;

  steps: string[];
  ingredients: RecipeIngredientDto[];
}
