using System;
using System.Linq;
using System.Collections.Generic;
using AoCHelperClasses;

namespace Day4
{
    public class Passport
    {
        public string BirthYear { get; set; }

        public string IssueYear { get; set; }

        public string ExpirationYear { get; set; }

        public string Height { get; set; }

        public string HairColour { get; set; }

        public string EyeColour { get; set; }

        public string PassportID { get; set; }

        public string CountryID { get; set; }

        public bool HasRequiredFields
        {
            get
            {
                return
                    !string.IsNullOrWhiteSpace(BirthYear) &&
                    !string.IsNullOrWhiteSpace(IssueYear) &&
                    !string.IsNullOrWhiteSpace(ExpirationYear) &&
                    !string.IsNullOrWhiteSpace(Height) &&
                    !string.IsNullOrWhiteSpace(HairColour) &&
                    !string.IsNullOrWhiteSpace(EyeColour) &&
                    !string.IsNullOrWhiteSpace(PassportID);
            }
        }

        public bool IsBirthYearValid
        {
            get
            {
                return BirthYear.DoesMatchPattern(@"^([1,2]((00[0-2])|(9[2-9]\d)))$");
            }
        }

        public bool IsIssueYearValid
        {
            get
            {
                return IssueYear.DoesMatchPattern(@"^(20((20)|(1\d)))$");
            }
        }

        public bool IsExpirationYearValid
        {
            get
            {
                return IssueYear.DoesMatchPattern(@"^(20((30)|(2\d)))$");
            }
        }

        public bool IsHeightValid
        {
            get
            {
                return Height.DoesMatchPattern(@"^((((1[5-8]\d)|(19[0-3]))cm)|(((59)|(6\d)|(7[0-6]))in))$");
            }
        }

        public bool IsHairColourValid
        {
            get
            {
                return HairColour.DoesMatchPattern(@"^(#(\d|[a-f]){6})$");
            }
        }

        public bool IsEyeColourValid
        {
            get
            {
                return EyeColour.DoesMatchPattern(@"^((amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth))$");
            }
        }

        public bool IsPassportIDValid
        {
            get
            {
                return PassportID.DoesMatchPattern(@"^(\d{9})$");
            }
        }

        public bool AreFieldsValid
        {
            get
            {
                return
                    IsBirthYearValid &&
                    IsIssueYearValid &&
                    IsExpirationYearValid &&
                    IsHeightValid &&
                    IsHairColourValid &&
                    IsEyeColourValid &&
                    IsPassportIDValid;
            }
        }

        public static Passport ParseString(string passportLine)
        {
            List<KeyValuePair<string, string>> valuePairs = passportLine
                .Split(' ')
                .AsParallel()
                .Select(anon => new KeyValuePair<string, string>(anon.Split(':')[0], anon.Split(':')[1]))
                .ToList();
            var passport = new Passport();
            foreach(var pair in valuePairs)
            {
                switch(pair.Key)
                {
                    case "byr":
                        passport.BirthYear = pair.Value;
                        break;
                    case "iyr":
                        passport.IssueYear = pair.Value;
                        break;
                    case "eyr":
                        passport.ExpirationYear = pair.Value;
                        break;
                    case "hgt":
                        passport.Height = pair.Value;
                        break;
                    case "hcl":
                        passport.HairColour = pair.Value;
                        break;
                    case "ecl":
                        passport.EyeColour = pair.Value;
                        break;
                    case "pid":
                        passport.PassportID = pair.Value;
                        break;
                    case "cid":
                        passport.CountryID = pair.Value;
                        break;
                    default:
                        break;
                }
            }
            return passport;
        }
    }
}
