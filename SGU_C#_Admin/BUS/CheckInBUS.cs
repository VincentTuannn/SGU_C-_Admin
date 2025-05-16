using SGU_C__User.DAO;
using SGU_C__User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C__User.BUS
{
    internal class CheckInBUS
    {
        private CheckInDAO checkInDAO = new CheckInDAO();

        public List<CheckInDTO> GetAllCheckIn()
        {
            return checkInDAO.GetAllCheckIn();
        }

        public List<CheckInDTO> GetAllCheckInByMaNguoiDung(int maNguoiDung)
        {
            try
            {
                return checkInDAO.GetAllCheckInByMaNguoiDung(maNguoiDung);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm checkin theo mã người dùng: " + ex.Message);
            }
        }

        public void AddCheckIn(CheckInDTO checkIn)
        {
            // Kiểm tra logic nghiệp vụ trước khi thêm
            if (checkIn.MaNguoiDung <= 0)
            {
                throw new Exception("Mã người dùng phải lớn hơn 0!");
            }
            if (checkIn.ThoiGianVao >= checkIn.ThoiGianRa)
            {
                throw new Exception("Thời gian vào phải nhỏ hơn thời gian ra!");
            }
            if (!new List<string> { "Checked In", "Checked Out" }.Contains(checkIn.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            checkInDAO.AddCheckIn(checkIn);
        }

        public void UpdateCheckIn(CheckInDTO checkIn)
        {
            // Kiểm tra logic nghiệp vụ trước khi cập nhật
            if (checkIn.MaNguoiDung <= 0)
            {
                throw new Exception("Mã người dùng phải lớn hơn 0!");
            }
            if (checkIn.ThoiGianVao >= checkIn.ThoiGianRa)
            {
                throw new Exception("Thời gian vào phải nhỏ hơn thời gian ra!");
            }
            if (!new List<string> { "Checked In", "Checked Out" }.Contains(checkIn.TrangThai))
            {
                throw new Exception("Trạng thái không hợp lệ!");
            }
            checkInDAO.UpdateCheckIn(checkIn);
        }

        public void DeleteCheckIn(int maCheckIn)
        {
            checkInDAO.DeleteCheckIn(maCheckIn);
        }

        public int GetCheckInCountsByDate()
        {
            try
            {
                List<CheckInDTO> checkIns = checkInDAO.GetCheckInCountsByDate();
                // Tính tổng số check-in từ danh sách
                return checkIns.Count;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy số lượng check-in theo ngày: " + ex.Message);
            }
        }

        public List<CheckInDTO> GetAllCheckInByDate(DateTime date)
        {
            var all = GetAllCheckIn();
            return all.Where(c => c.ThoiGianVao.Date == date.Date).ToList();
        }

        public int GetCheckInCountsByDates(DateTime date)
        {
            try
            {
                return checkInDAO.GetCheckInCountsByDates(date);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy số lượng check-in theo ngày: " + ex.Message);
            }
        }
    }
}
