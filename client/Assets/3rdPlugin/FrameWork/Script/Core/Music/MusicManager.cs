using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Core.Music
{
    public class MusicManager
    {
        static public void Init(AudioSource audioSource)
        {
            audio = audioSource;
        }

        static private AudioSource audio;

        private static MusicManager _instarnce;

        public static MusicManager GetInstance()
        {
            if (_instarnce == null)
            {
                _instarnce = new MusicManager();
            }
            return _instarnce;
        }

        private MusicManager()
        {
        }

        private Hashtable sounds = new Hashtable();

        /// <summary>
        /// 添加一个声音
        /// </summary>
        public void Add(string key, AudioClip value)
        {
            if (sounds[key] != null || value == null) return;
            sounds.Add(key, value);
        }

        /// <summary>
        /// 获取一个声音
        /// </summary>
        public AudioClip Get(string key)
        {
            if (sounds[key] == null) return null;
            return sounds[key] as AudioClip;
        }

        /// <summary>
        /// 载入一个音频
        /// </summary>
        public AudioClip LoadAudioClip(string path)
        {
            AudioClip ac = Get(path);
            if (ac == null)
            {
                ac = (AudioClip)Resources.Load(path, typeof(AudioClip));
                Add(path, ac);
            }
            return ac;
        }

        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="canPlay"></param>
        public void PlayBacksound(string name, bool canPlay)
        {
            if (audio.clip != null)
            {
                if (name.IndexOf(audio.clip.name) > -1)
                {
                    if (!canPlay)
                    {
                        audio.Stop();
                        audio.clip = null;
                    }
                    return;
                }
            }
            if (canPlay)
            {
                audio.loop = true;
                audio.clip = LoadAudioClip(name);
                audio.Play();
            }
            else
            {
                audio.Stop();
                audio.clip = null;
            }
        }
    }
}
