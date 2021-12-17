import { RecipeIngredientDto } from "../../Dtos/recipe-ingredient-dto";
import { AddRecipeStepDto } from "./add-recipe-step-dto";

export interface AddRecipeDto {
  image: File;

  imageUrl: string;

  authorUsername: string

  title: string;
  description: string;

  tags: string[];
  tagsString: string;

  cookingTime: number;
  personsCount: number;

  ingredients: RecipeIngredientDto[];
  steps: AddRecipeStepDto[];
}
