window.playPauseAudio = function (isPlaying) {
    var audio = document.getElementById('audioPlayer');
    if (isPlaying) {
        audio.play();
    } else {
        audio.pause();
    }
};

window.skipAudio = function (seconds) {
    var audio = document.getElementById('audioPlayer');
    audio.currentTime += seconds;
};
