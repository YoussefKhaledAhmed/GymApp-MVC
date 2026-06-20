using GymApp.BusinessLogic.Services.DTOs.AddressDetails;
using GymApp.BusinessLogic.Services.DTOs.HealthRecords;
using GymApp.BusinessLogic.Services.DTOs.Members;
using GymApp.BusinessLogic.Services.MemberServices;
using GymApp.Presentation.ViewModels.Members;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Presentation.Controllers;

public class MembersController(IMemberService memberService) : Controller
{
    private readonly IMemberService _memberService = memberService;
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await _memberService.GetAllAsync(cancellationToken: cancellationToken);

        if (!result.IsSuccess)
        {
            return StatusCode(500, result.ErrMsg);
        }

        var membersViewModel = result.Value!.Select(m => new MemberIndexViewModel
        {
            Id = m.Id,
            Email = m.Email,
            Gender = m.Gender.ToString(),
            JoinDate = DateOnly.FromDateTime(m.JoinDate),
            Name = m.Name,
            Phone = m.Phone,
            PhotoUrl = m.PhotoURL
        }).ToList();
        return View(membersViewModel);
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MemberCreateViewModel memberViewModel, CancellationToken cancellationToken)
    {

        var memberDto = new MemberDto
        {
            Name = memberViewModel.Name,
            Address = new AddressDetailsDto
            {
                BuildingNo = memberViewModel.BuildingNumber,
                Street = memberViewModel.Street,
                City = memberViewModel.City
            },
            Email = memberViewModel.Email,
            DateOfBirth = memberViewModel.DateOfBirth.ToDateTime(TimeOnly.MinValue),
            Gender = memberViewModel.Gender,
            Phone = memberViewModel.Phone,
            HealthRecordsDto = new HealthRecordsDto
            {
                BloodType = memberViewModel.HealthRecordViewModel.BloodType,
                Height = memberViewModel.HealthRecordViewModel.Height,
                Weight = memberViewModel.HealthRecordViewModel.Weight,
                Note = memberViewModel.HealthRecordViewModel.Note
            }
        };

        if (!ModelState.IsValid) {
            return View(memberViewModel);
        }


        var result = await _memberService.CreateAsync(memberDto, cancellationToken);

        TempData["MembersCreationIsSuccess"] = result.IsSuccess;

        if (!result.IsSuccess)
        {
            ModelState.AddModelError(result.ErrKey! , result.ErrMsg!);
            return View(memberViewModel);
        }

        

        return RedirectToAction(nameof(Index), "Members");
    }
}