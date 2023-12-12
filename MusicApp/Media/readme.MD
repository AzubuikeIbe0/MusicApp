@foreach(MusicItem item in MediaTable  )
 <tfoot>
                            <@Pagination TotalPages="@(totalPages != 0 ? totalPages : 1)" PageIndex="@pageIndex" Radius="3" OnSelectedPage="SelectedPage">
                            </@Pagination>
                        </tfoot>
  protected override async Task OnInitializedAsync()
    {
        try
        {
            @* Media = await MusicService.GetMedia(); *@
            allMusic = await MusicService.GetMedia();
            ChartListData = await MusicService.GetChartList(); 
            // ArtistTopSongs = await MusicService.GetArtistTopSongs(); 
            if(allMusic != null)
            {
                totalPages = (int)(allMusic.Count() / itemsPerPage);

                MediaTable = allMusic.Skip(0).Take(itemsPerPage);
            }
        }
        catch (Exception e)
        {
            Error = e.Message;
        }

         private void SelectedPage(int selectedPageIndex)
        {
            if (allMusic != null)
            {
                pageIndex = selectedPageIndex;
                var skipCount = itemsPerPage * (pageIndex - 1);
                MediaTable = allMusic.Skip(skipCount).Take(itemsPerPage).ToList();
            }
        }
    }