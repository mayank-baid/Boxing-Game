mergeInto(LibraryManager.library, {
  GameOver: function (scoreCount) {
    window.dispatchReactUnityEvent(
      "GameOver",
      scoreCount
    );
  },
});