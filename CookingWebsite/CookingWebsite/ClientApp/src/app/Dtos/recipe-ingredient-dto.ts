import { RecipeIngredientItemDto } from './recipe-ingredient-item-dto';

export interface RecipeIngredientDto {
  title: string;
  ingredientsList: RecipeIngredientItemDto[];
}
