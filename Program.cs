using System.Collections.Generic;
HashSet<string> stations_needed = new HashSet<string>();
stations_needed.Add("mt");
stations_needed.Add("wa");
stations_needed.Add("or");
stations_needed.Add("id");
stations_needed.Add("nv");
stations_needed.Add("ut");
stations_needed.Add("ca");
stations_needed.Add("az");
Dictionary<string, HashSet<string>> stations = new Dictionary<string, HashSet<string>>();
HashSet<string> kone = new HashSet<string>();
kone.Add("id");
kone.Add("nv");
kone.Add("ut");
stations.Add("kone", kone);
HashSet<string> ktwo = new HashSet<string>();
ktwo.Add("wa");
ktwo.Add("id");
ktwo.Add("mt");
stations.Add("ktwo", ktwo);
HashSet<string> kthree = new HashSet<string>();
kthree.Add("or");
kthree.Add("nv");
kthree.Add("ca");
stations.Add("kthree", kthree);
HashSet<string> kfour = new HashSet<string>();
kfour.Add("ut");
kfour.Add("nv");
stations.Add("kfour", kfour);
HashSet<string> kfive = new HashSet<string>();
kfive.Add("az");
kfive.Add("ca");
stations.Add("kfive", kfive);
Dictionary<string, HashSet<string>> stations2 = new Dictionary<string, HashSet<string>>();
stations2.Add("kone", kone);
stations2.Add("ktwo", ktwo);
stations2.Add("kthree", kthree);
stations2.Add("kfour", kfour);
stations2.Add("kfive", kfive);
HashSet<string> stations_covered = new HashSet<string>();
int count = 0;
string best_station="";
HashSet<string> all = new();
while (stations_covered.Count != stations_needed.Count)
{
    Dictionary<string, HashSet<string>>.ValueCollection valueColl = stations2.Values;
    foreach (HashSet<string> i in valueColl)
    {
        string this_station = stations.FirstOrDefault(kvp => kvp.Value == i).Key;
        i.ExceptWith(stations_covered);
        if (count < i.Count)
        {
            count = i.Count;
            best_station = this_station;
        }
    }
    count = 0;
    all.Add(best_station);
    foreach (string i in stations[best_station])
        stations_covered.Add(i);
    stations2.Remove(best_station);
}
foreach (string i in all)
    Console.WriteLine(i);

