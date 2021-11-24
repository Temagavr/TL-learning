﻿using CookingWebsite.Application.Recipe.RecipeDtos;
using CookingWebsite.Domain;
using CookingWebsite.Domain.Entities.Recipes;
using CookingWebsite.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipe
{
    public class RecipeService : IRecipeService
    {

        private readonly IRecipeRepository _recipeRepostitory;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepostitory = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddRecipe (AddRecipeDto addRecipeDto)
        {
            var recipe = new Domain.Entities.Recipes.Recipe(
                imageUrl: "image",
                addRecipeDto.Title,
                addRecipeDto.Description,
                addRecipeDto.CookingTime,
                addRecipeDto.PersonsCount,
                likesCount: 0,
                favouritesCount: 0,
                addRecipeDto.AuthorUsername
            );

            _recipeRepostitory.Add(recipe);

            await _unitOfWork.Commit();
        }

        public async Task<Domain.Entities.Recipes.Recipe> GetRecipe(int recipeId)
        {
            var recipe = await _recipeRepostitory.GetById(recipeId);

            return recipe;
        }

        public async Task<RecipeDetailsDto> GetRecipeDetails(int recipeId)
        {
            var recipe = await _recipeRepostitory.GetById(recipeId);

            var recipeDetailsDto = new RecipeDetailsDto();

            recipeDetailsDto.Title = recipe.Title;
            recipeDetailsDto.Description = recipe.Description;
            recipeDetailsDto.AuthorUsername = recipe.AuthorUsername;
            recipeDetailsDto.CookingTime = recipe.CookingTime;
            recipeDetailsDto.FavouritesCount = recipe.FavouritesCount;
            recipeDetailsDto.Id = recipe.Id;
            recipeDetailsDto.ImageUrl = recipe.ImageUrl;
            recipeDetailsDto.LikesCount = recipe.LikesCount;
            recipeDetailsDto.PersonsCount = recipe.PersonsCount;
            
            //recipeIngredientDto.Title = recipeIngredient.Title;
            //recipeIngredientDto.RecipeId = recipeIngredient.RecipeId;


            return recipeDetailsDto;
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var recipe = _recipeRepostitory.GetById(recipeId);

            _recipeRepostitory.Delete(recipe);

            await _unitOfWork.Commit();
        }
    }
}