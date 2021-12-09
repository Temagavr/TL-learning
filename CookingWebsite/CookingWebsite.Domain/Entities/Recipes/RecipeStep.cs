namespace CookingWebsite.Domain.Entities.Recipes
{
    public class RecipeStep
    {
        public int Id { get; private set; }
        public int RecipeId { get; private set; }
        public int StepNumber { get; private set; }
        public string Description { get; private set; }

        protected RecipeStep() { }

        public RecipeStep(
            int stepNumber,
            string description
            )
        {
            StepNumber = stepNumber;
            Description = description;
        }
    }
}
