using Homework13;
using Homework13.FileOperations;

TimeCoordinator timeCoordinator = new TimeCoordinator();

timeCoordinator.Cordinate(new List<Cassa>
{
    new Cassa(22),
    new Cassa(11),
    new Cassa(0)
}, "../../../Files/Persons.txt");



