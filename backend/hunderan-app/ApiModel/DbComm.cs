using System;
using hunderan_app.Data;
using hunderan_app.Model;
using Microsoft.EntityFrameworkCore;

namespace hunderan_app.ApiModel
{
	public class DbComm
	{
		private ApiDbContext _context;

		public DbComm(ApiDbContext context)
		{
			_context = context;
		}

		public List<DictModel> GetTraslatedtext()
		{
			List<DictModel> response = new List<DictModel>();

			var transletedText = _context.Dicts.ToList();
			transletedText.ForEach(row => response.Add(new DictModel()
			{
				Id = row.Id,
				SourceEng=row.SourceEng,
				Targetlanguage=row.Targetlanguage

			}));

			return response;
          
        }
/*

        public List<DictModel> GetTraslatedByText(string engText)
        {
            List<DictModel> response = new List<DictModel>();
            var transletedText = _context.Dicts.ToList();
			 
            transletedText.ForEach(row => response.Add(new DictModel()
            {
                Id = row.Id,
                SourceEng = row.SourceEng,
                Targetlanguage = row.Targetlanguage

            }));


            if (!string.IsNullOrEmpty(engText))
            {
				response = (List<DictModel>)response.Where(text => text.SourceEng == engText);

				if (response != null)
				{
					var transletdText = response.FirstOrDefault().Targetlanguage;

					
				}
                            
            }

			return response;
        }
   

		*/



}
}

