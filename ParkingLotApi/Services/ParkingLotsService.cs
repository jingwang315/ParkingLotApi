﻿using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository parkingLotsRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository)
        {
            this.parkingLotsRepository = parkingLotsRepository;
        }
        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return await parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }

        public async Task DeleteAsync(string id) =>
            await parkingLotsRepository.DeleteParkingLot(id);

        public async Task<ParkingLot> GetByIdAsync(string id) =>
            await parkingLotsRepository.GetParkingLotById(id);
    }
}
