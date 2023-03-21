using Fitness_All_in_One.Data;

internal class ThreadSafeDbContext
{
    private ApplicationDbContext applicationDbContext;

    public ThreadSafeDbContext(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }
}