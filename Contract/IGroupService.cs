using WebAPI.DTO;

namespace WebAPI.Contract
{
    public interface IGroupService
    {
        public void Add(GroupDTO group);
        public void Update(GroupDTO group, int Id);
        public void Delete(int Id);
        public void Find();
    }
}
