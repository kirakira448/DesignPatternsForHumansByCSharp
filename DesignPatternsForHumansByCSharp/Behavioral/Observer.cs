namespace Behavioral
{
    public class Observer
    {
        class JobPost
        {
            private string title;
            public JobPost(string title)
            {
                this.title = title;
            }

            public string GetTitle()
            {
                return title;
            }
        }
        
        interface IObserver<T>
        {
            void OnJobPosted(T jobPost);
        }
        
        class JobSeeker : IObserver<JobPost>
        {
            public string Name { get; }
            public JobSeeker(string name)
            {
                Name = name;
            }

            public void OnJobPosted(JobPost jobPost)
            {
                Console.WriteLine($"Hi {Name}! New job posted: {jobPost.GetTitle()}");
            }
        }
        
        interface IObservable<T>
        {
            void attach(IObserver<T> observer);
            void notify(JobPost jobPost);
        }

        class EmploymentAgency : IObservable<JobPost>
        {
            private List<IObserver<JobPost>> observers = new List<IObserver<JobPost>>();

            public void attach(IObserver<JobPost> observer)
            {
                observers.Add(observer);
            }

            public void notify(JobPost jobPost)
            {
                foreach (var observer in observers)
                {
                    observer.OnJobPosted(jobPost);
                }
            }
            
            public void addJob(JobPost jobPost) 
            {
                notify(jobPost);
            }
        }

        public static void DemonstrateObserver()
        {
            EmploymentAgency employmentAgency = new EmploymentAgency();
            JobSeeker jobSeeker1 = new JobSeeker("John Doe");
            JobSeeker jobSeeker2 = new JobSeeker("Jane Smith");

            employmentAgency.attach(jobSeeker1);
            employmentAgency.attach(jobSeeker2);

            employmentAgency.addJob(new JobPost("Software Engineer"));
        }
    }
}