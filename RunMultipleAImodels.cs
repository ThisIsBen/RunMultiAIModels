static int Main(string[] args)
{
    var tasks = new List<Task>();

    int numOfModel=10;

    for (var i = 0; i < numOfModel; i++)
    {
        // work around for closure behavior
        var j = i;

        tasks.Add(Task.Run(() =>
        {
            // use the new j variable here
            runViDi(modelPath,j);
        }));
    }

    
}

private  void runViDi(string modelPath,int No)
{
    //Read in ViDi model

    //
    foreach(string imagePath in Directory.GetFiles(@"c:\Dir\", "*.jpg"))
    {
       //Inspect an image
       InpsectAnImage(imagePath,No);

    }
}

private async void InpsectAnImage(string imagePath,int No)
{
    //Read in the image
    
    //Inspect the image
    sw.Restart();
    


    sw.Stop();
    long elapsedTime=sw.ElapsedMillisecond();

    //Write processing time to a file
    await File.AppendAllTextAsync($"ProcessingTime{No}.csv", "ViDi処理時間,{elapsedTime}/n");
}
