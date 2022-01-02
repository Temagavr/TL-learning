import { RecipeIngredientDto } from './recipe-ingredient-dto';

export interface RecipeDetailsDto {
  imageUrl: string;

  authorUsername: string

  title: string;
  description: string;

  tags: string[];

  isCanModify: boolean;

  isFavourite: boolean;
  isLiked: boolean;

  favourite: number;
  likesCount: number;
  cookingTime: number;
  personsCount: number;

  steps: string[];
  ingredients: RecipeIngredientDto[];
}
