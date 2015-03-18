using UnityEngine;

namespace Core.Music
{
    public class BackGroundSoundManager
    {
        static private BackGroundSoundManager _instance;

        static public BackGroundSoundManager GetInstance()
        {
            if(null == _instance){
                _instance = new BackGroundSoundManager();
            }
            return _instance;
        }

        private AudioSource _audioSource;

        private BackGroundSoundManager(){}

        public void Init(AudioSource source)
        {
            this._audioSource = source;
        }

        public void Play(AudioClip clip)
        {
            Destory();

            _audioSource.loop = true;
            _audioSource.clip = clip;
            _audioSource.Play ();
        }

        public void Stop()
        {
            if (_audioSource.clip != null)
            {
                _audioSource.Stop();
            }
        }

        public void Destory()
        {
            if (_audioSource.clip != null)
            {
                _audioSource.Stop();
                var tclip = _audioSource.clip;
                _audioSource.clip = null;
                Resources.UnloadAsset(tclip);
            }
        }
    }
}
