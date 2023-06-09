﻿using Hotel.Application.Abstractions;
using Hotel.Domain.Abstractions;
using Hotel.Domain.Entities;

namespace Hotel.Application.Services
{
    public class BookingDataService : IBookingDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<BookingData> _bookingDataRepository;

        public BookingDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookingDataRepository = unitOfWork.BookingDataRepository;
        }

        public async Task<BookingData> AddAsync(BookingData item)
        {
            await _bookingDataRepository.AddAsync(item);
            await _unitOfWork.SaveAllAsync();
            return item;
        }

        public async Task<BookingData> DeleteAsync(int id)
        {
            var booking = await _bookingDataRepository.GetByIdAsync(id, includesProperties: (booking) => booking.Room);
            await _bookingDataRepository.DeleteAsync(booking);
            await _unitOfWork.SaveAllAsync();
            return booking;
        }

        public async Task<IEnumerable<BookingData>> GetAllAsync()
        {
            return await _bookingDataRepository.ListAllAsync(default, (booking) => booking.Room, (booking) => booking.User);
        }

        public async Task<BookingData> GetByIdAsync(int id)
        {
            return await _bookingDataRepository.GetByIdAsync(id, includesProperties: (booking) => booking.Room);
        }

        public async Task<IEnumerable<BookingData>> GetUserById(int id)
        {
            return await _bookingDataRepository.ListAsync((booking) => booking.UserId == id);
        }

        public async Task<BookingData> UpdateAsync(BookingData item)
        {
            await _bookingDataRepository.UpdateAsync(item);
            await _unitOfWork.SaveAllAsync();
            return item;
        }

        public Task GetConnections()
        {
            _unitOfWork.BookingDataRepository.ListAllAsync();
            _unitOfWork.UserRepository.ListAllAsync();
            _unitOfWork.RoomRepository.ListAllAsync();
            return Task.CompletedTask;
        }
    }
}
